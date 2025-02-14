﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Server.Models;

public class OrderTable
{
    public int Id { get; set; }

    [Display(Name = "First name")]
    [StringLength(60, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Display(Name = "Last name")]
    [StringLength(60, MinimumLength = 3)]
    public string LastName { get; set; }

    [Display(Name = "Phone number"), DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Display(Name = "Reservation time"), DataType(DataType.DateTime)]
    public DateTime ReservationTime { get; set; }

    [Display(Name = "Number of guests")]
    [Range(1, 20)]
    public int DinnerGuests { get; set; }

    [Required(ErrorMessage = "Please select restaurant branch.")]
    public int RestaurantBranchId { get; set; }

    [Display(Name = "Restaurant branch")]
    [JsonIgnore]
    public virtual RestaurantBranch RestaurantBranch { get; set; }
}
