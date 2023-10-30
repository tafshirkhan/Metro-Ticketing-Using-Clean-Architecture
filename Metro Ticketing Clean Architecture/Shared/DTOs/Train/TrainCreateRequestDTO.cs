﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Train;

public record TrainCreateRequestDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ArrivalTime { get; set; } 
    public string DepartureTime { get; set; }   
    public DateTime ArrivalDate { get; set; }   
    public DateTime DepartureDate { get; set; }  
    public string ArrivalStation { get; set; }
    public string DepartureStation { get; set; }
    public double Distance { get; set; }
    public bool isActive { get; set; } = false;
}

