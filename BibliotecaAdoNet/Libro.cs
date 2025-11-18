using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BibliotecaAdoNet
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }

        // Guardamos la ruta (string) en la BD
        public string Portada { get; set; }

        public Libro() { }

        public Libro(string titulo, string autor, string editorial, string portada)
        {
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            Portada = portada;
        }

        // Esto no se guarda en BD (solo se usa en UI)
        [NotMapped]
        public ImageSource ImagenPortada =>
            string.IsNullOrEmpty(Portada) ? null : ImageSource.FromFile(Portada);
    }
}
