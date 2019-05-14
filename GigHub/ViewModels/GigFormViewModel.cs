using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required (ErrorMessage = "Venue field is required.")]
        public string Venue { get; set; }
        [Required (ErrorMessage = "Date field is required.")]
        [FutureDate]
        public string Date { get; set; }
        [Required (ErrorMessage = "Time field is required.")]
        [ValidTime]
        public string Time { get; set; }
        [Required (ErrorMessage = "Please select a Genre.")]
        public byte Genre { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}