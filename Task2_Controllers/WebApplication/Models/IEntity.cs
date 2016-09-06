using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_CustomFactory.Models
{
    public interface IEntity
    {
        int Id { get; set; }
    }
}
