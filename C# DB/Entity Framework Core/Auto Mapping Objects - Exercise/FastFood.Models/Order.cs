﻿namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; } = null!;

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [NotMapped]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(Employee))]
        public int EmployeeId { get; set; }

        [Required]
        public virtual Employee Employee { get; set; } = null!;

        public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
    }
}