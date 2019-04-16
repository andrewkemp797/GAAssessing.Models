﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAAssessing.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTimeOffset DateCreated { get; set; }
        bool IsRetired { get; set; }
    }
}
