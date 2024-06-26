﻿namespace PersonalCare.Domain.Entities
{
    public class CategoriaTreino
    {
        public CategoriaTreino(int _id)
        {
            Id = _id;
            Nome = string.Empty;
        }

        public CategoriaTreino(string _nome)
        {
            Nome = _nome;
        }

        public CategoriaTreino(int _id, string _nome)
        {
            Id = _id;
            Nome = _nome;
        }

        public int Id { get; }
        public string Nome { get; }
    }
}
