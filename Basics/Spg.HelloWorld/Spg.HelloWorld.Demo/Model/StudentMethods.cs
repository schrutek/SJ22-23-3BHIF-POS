using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.HelloWorld.Demo.Model
{
    public partial class Student
    {
        /// <summary>
        /// Zusammenfassung der Funktion (ein Satz)
        /// </summary>
        /// <remarks>
        /// Detaillierte Beschreibung der Methode.
        /// </remarks>
        /// <see cref="Spg.HelloWorld.Demo.Model.EntityBase"/>
        /// <exception cref="NotImplementedException">Beschreibung der Exception, wann wird sie geworfen</exception>
        public void Dispose()
        {
            int myNumber = 5;

            throw new NotImplementedException();
        }

        /// <summary>
        /// Meine Save-Methode...
        /// </summary>
        /// <remarks>
        /// Beschreibung der Methode...
        /// </remarks>
        /// <exception cref="CouldNotSaveException">Beschreibung der Exception...</exception>
        public void Save()
        {
            try
            {
                // Save...
            }
            catch (DbUpdateException ex)
            {
                throw new CouldNotSaveException("Speichern fehlgeschlagen!");
            }
        }
    }
}
