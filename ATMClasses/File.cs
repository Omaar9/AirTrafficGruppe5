using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATMClasses
{
    public class File
    {
        private object fileWriter;

        public void Update(ConditionDetecter conditionDetecter)
        {
            StreamWriter _fileWriter = new StreamWriter(@"C: \Users\Brug\Desktop\AirTrafficGruppe5\ATMClasses\bin\Debug\logfile.txt");
            
            _fileWriter.WriteLine(conditionDetecter);

            _fileWriter.Flush();
        }

    }
}
