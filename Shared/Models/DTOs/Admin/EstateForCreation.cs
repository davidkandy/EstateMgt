﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models.DTOs.Admin
{
    public class EstateForCreation
    {
        public string Company { get; set; }
        public Guid Id { get; set; }
            
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Name { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Description { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string Street { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed")]
        public string City { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed")]
        public string Country { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum of 10 characters allowed")]
        public string PostalCode { get; set; }
        [MaxLength(30, ErrorMessage = "Maximum of 30 characters allowed")]
        public string State { get; set; }
        public string Geolocation { get; set; }
        public int Size { get; set; }
        public string Status { get; set; }

        //public DateTime StartDate { get; set; }
        //public DateTime DateCompleted { get; set; }
    }
}
