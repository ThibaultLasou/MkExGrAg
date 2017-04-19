using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS_CS.Models
{
    //Interface définissant la Data Access Layer (ou couche d'accès aux données)
    public interface IDal : IDisposable
    {
        Individu Authenticate(string username, int password);

        Individu ObtenirInidividu();
    }
}
