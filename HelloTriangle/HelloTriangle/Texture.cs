


namespace HelloTriangle
{
    public struct Texture
    {
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public Texture(int id, int width, int height) : this()
        {
            Id = id;
            Height = height;
            Width = width;
        }

    }
  
}
