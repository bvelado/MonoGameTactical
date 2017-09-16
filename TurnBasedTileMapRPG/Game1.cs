using System.Diagnostics;
using Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TurnBasedTileMapRPG.Screen;

namespace TurnBasedTileMapRPG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ScreenController screenController;

        HumanCharacter[] characters;
        SpriteFont debugFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            screenController = new ScreenController(graphics);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenController.Initialize();

            BaseClass[] baseClasses = Content.Load<BaseClass[]>("baseClasses");

            characters = new HumanCharacter[3];
            characters[0] = new HumanCharacter("Harold", new Class(baseClasses[0]));
            characters[1] = new HumanCharacter("Mary", new Class(baseClasses[2]));
            characters[2] = new HumanCharacter("Chester", new Class(baseClasses[1]));

            BaseEquipment[] equipmentsData = Content.Load<BaseEquipment[]>("baseEquipments");
            Equipment[] equipments = new Equipment[equipmentsData.Length];
            for (int i = 0; i < equipmentsData.Length; i++)
            {
                equipments[i] = new Equipment(equipmentsData[i]);
            }

            foreach(var equipment in equipments)
            {
                var randomCharacter = characters[RandomController.Instance.Range(0, characters.Length)];
                if (randomCharacter.Inventory.HasSlot(equipment.SlotType))
                {
                    randomCharacter.Inventory.SetEquipmentAt(equipment.SlotType, equipment);
                }
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            debugFont = Content.Load<SpriteFont>("Debug");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            screenController.BeginNative(spriteBatch);

            //
            // TODO: Add your drawing code here
            //

            Vector2 pos = new Vector2();
            for(int i = 0; i < characters.Length; i++)
            {
                spriteBatch.DrawString(debugFont, characters[i].ToString(), pos, Color.White);
                pos.Y += 100;
            }

            screenController.EndNative(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
