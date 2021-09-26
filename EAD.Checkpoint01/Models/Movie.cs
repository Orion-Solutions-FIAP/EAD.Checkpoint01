using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace EAD.Checkpoint01.Models
{
    public class Movie
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false), Display(Name = "Nome")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O Nome deve conter entre 2 e 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Snopse é obrigatório", AllowEmptyStrings = false), Display(Name = "Sinopse")]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "A Sinopse deve conter entre 10 e 255 caracteres")]
        public string Synopsis { get; set; }
        
        [Required(ErrorMessage = "O campo Data de Lançamento é obrigatório"), Display(Name = "Data de Lançamento"), DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        
        [Display(Name = "Em cartaz")]
        public bool InTheaters { get; set; }
        
        [Required(ErrorMessage = "O campo Duração é obrigatório"), Display(Name = "Duração"), DataType(DataType.Time)]
        public DateTime? Duration { get; set; }
        
        [Required(ErrorMessage = "Selecione uma categoria"), Display(Name = "Categorias")]
        public Category? Category { get; set; }
    }

    public enum Category
    {
        [Display(Name = "Comédia")]
        Comedy,
        [Display(Name = "Ação")]
        Action,
        [Display(Name = "Aventura")]
        Adventure,
        [Display(Name = "Terror")]
        Horror,
        [Display(Name = "Animação")]
        Animation,
        [Display(Name = "Romance")]
        Romance,
        [Display(Name = "Suspense")]
        Thriller
    }
}
