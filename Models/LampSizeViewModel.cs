using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Illumination.Models;

    public class LampSizeViewModel
    {
        public List<Lamp>? Lamps { get; set; }
        public SelectList? Sizes { get; set; }
        public string? LampSize { get; set; }
        public string? SearchString { get; set; }
    }
