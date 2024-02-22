using Microsoft.AspNetCore.Mvc.Rendering;
using Shawls_ReadyToWear.Models;
using System.Collections.Generic;

namespace Shawls_ReadyToWear.Models;

public class ShawlTitleViewModel
{
    public List<Shawl>? Shawls { get; set; }
    public SelectList? Title { get; set; }
    public string? ShawlTitle { get; set; }
    public string? SearchString { get; set; }
}