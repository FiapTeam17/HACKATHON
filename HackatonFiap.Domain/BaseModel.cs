namespace HackatonFiap.Dominio;

    public record BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }

