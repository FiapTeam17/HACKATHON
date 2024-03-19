namespace HackatonFiap.Dominio.Model;

    public record BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }

