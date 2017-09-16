using Data;

namespace TurnBasedTileMapRPG
{
    public class Class
    {
        private readonly string name;
        private readonly Attributes attributes;

        public string Name { get { return name; } }
        public Attributes Attributes { get { return attributes; } }

        public Class(BaseClass baseClass)
        {
            name = baseClass.Name;
            attributes = new Attributes(baseClass.Attributes);
        }

        public override string ToString()
        {
            return string.Format("{0}\r\n{1}", name, attributes.ToString());
        }
    }
}
