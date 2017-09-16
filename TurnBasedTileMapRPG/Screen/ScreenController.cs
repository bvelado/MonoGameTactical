using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TurnBasedTileMapRPG.Screen
{
    public class ScreenController
    {
        public const int NATIVE_RESOLUTION_WIDTH = 640;
        public const int NATIVE_RESOLUTION_HEIGHT = 360;

        private GraphicsDeviceManager graphics;
        private RenderTarget2D nativeRT;
        private Rectangle nativeRectangle;
        private Rectangle screenRectangle;

        public ScreenController(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;

            nativeRectangle = 
                new Rectangle(0,0, 
                NATIVE_RESOLUTION_WIDTH, NATIVE_RESOLUTION_HEIGHT);
            screenRectangle =
                new Rectangle(0, 0, 
                NATIVE_RESOLUTION_WIDTH * 2, NATIVE_RESOLUTION_HEIGHT * 2);

            graphics.PreferredBackBufferWidth = screenRectangle.Width;
            graphics.PreferredBackBufferHeight = screenRectangle.Height;
        }

        public void Initialize()
        {
            nativeRT = 
                new RenderTarget2D(graphics.GraphicsDevice, 
                nativeRectangle.Width, nativeRectangle.Height);
        }

        public void BeginNative(SpriteBatch spriteBatch)
        {
            graphics.GraphicsDevice.SetRenderTarget(nativeRT);
            graphics.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
        }

        public void EndNative(SpriteBatch spriteBatch)
        {
            spriteBatch.End();

            graphics.GraphicsDevice.SetRenderTarget(null);

            // RenderTarget2D inherits from Texture2D so we can render it just like a texture
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            spriteBatch.Draw(nativeRT, screenRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
