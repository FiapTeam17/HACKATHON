﻿namespace HackatonFiap.Dominio;

    public record BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }

