
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_Arch_GestStage_With_UOW.Dal.Entities;

namespace TF_Arch_GestStage_With_UOW.Dal.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static Enfant ToEnfant(this IDataRecord record)
        {
            return new Enfant()
            {
                Id = (int)record["Id"],
                Nom = (string)record["Nom"],
                Prenom = (string)record["Prenom"]
            };
        }

        internal static Stage ToStage(this IDataRecord record)
        {
            return new Stage()
            {
                Id = (int)record["Id"],
                Titre = (string)record["Titre"]
            };
        }
    }
}
