using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3Client {
    public class Parameters {
        // el path del fichero de configuraion
        private static string CONFIG_FILE = "PARAMS.CFG";
        //la estructura basica de la entidad de parametros
        private List<ParamsSection> parameters = new List<ParamsSection>();
        public Parameters() {
            readFile();
        }
        private void readFile() {
            //lee el fichero y compone una lista con una linea cada elemento
            try {
                using (StreamReader sr = new StreamReader(CONFIG_FILE)) {
                    //Leemos el Stream del fichero

                    int counter = 0;
                    string line;
                    List<string> listOfLines = new List<string>();
                   
                    while ((line = sr.ReadLine()) != null) {
                        listOfLines.Add(line);
                        counter++;
                    }

                    sr.Close();                   
                    parseParams(listOfLines);
                    
                }
            } catch (Exception e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

            }
            
        }
     
        private void parseParams(List<string> paramFileLines) {

            //lee y enterpreta los parametros de el fichero y popula la estructura basica
           
            for (int i = 0; i < paramFileLines.Count(); i++) {
                string stringedName = paramFileLines[i].ToString();
                
                if ( isSectionName(stringedName) ) {
                    string name = cleanSectionName( stringedName );
                    ParamsSection ps = new ParamsSection(name);

                    parameters.Add(ps);
                    
                } else if( !isCommentedString(stringedName)  ) {
                    string [] paramKeyValue = getKeyValueParameter(stringedName);
                    int sectionIndex = parameters.Count();
                    parameters[sectionIndex-1].addParameter(paramKeyValue[0], paramKeyValue[1]);
                }
            }

               
            
        }
        private bool isSectionName( string line) {
            if (line.Contains("[") || line.Contains("]")) return true;
            return false;
        }
        private bool isCommentedString( string line) {
            if (!line.Split(';')[0].Contains('=')) return true;

            return false;
        }
        private string cleanSectionName( string dirtyName ) {
            //limpia los nombres de la sectiones 
            return dirtyName.Replace("[", "").Replace("]", "").Replace("_", " ").Trim();
        
        }


        private string [] getKeyValueParameter( string wholeParameter) {
            //compone un array con la clave y el valore 
            string[] splitted = wholeParameter.Split('=');
            splitted[1] = splitted[1].Split(';')[0].Trim();
            splitted[0] = splitted[0].Trim();      
            return splitted;
        }
        public string getFormattedParams() {
            //prepara una stringa formattada por el campo de texto
          
            string parametersText = "";
            string newLine = Environment.NewLine;
            for( int j = 0; j< parameters.Count(); j++) {
                parametersText += newLine + parameters[j].getName() + newLine;
                parametersText += "----------------------------------" + newLine;

                for (int i = 0; i < parameters[j].getAllParameters().Count(); i++) {
                    string name = parameters[j].getAllParameters()[i].getKey();
                    string value = parameters[j].getAllParameters()[i].getValue();
                    parametersText += name + " : " + value + newLine;

                }
            }
            return parametersText;
        }
       
        public ParamsSection getSectionByName(string sectionName) {
            foreach( ParamsSection section in parameters) {
                if(section.getName() == sectionName) {
                    return section;
                }
            }
            return null;

        }
        public void saveParameters() {
            //Guarda los parametros en un nuevo fichero
            try {
                using (StreamReader sr = new StreamReader(CONFIG_FILE)) {
                    string tmpConfigFile = CONFIG_FILE + ".tmp";
                    Console.WriteLine(tmpConfigFile);
                    //Leemos el Stream del fichero

                    int counter = 0;
                    string line;
                    List<string> listOfLines = new List<string>();
                    List<string> newListOfLines = new List<string>();
                    while ((line = sr.ReadLine()) != null) {
                        listOfLines.Add(line);
                        counter++;
                    }
                    string sectionName = "";

                    foreach (string fileLine in listOfLines) {
                        string tmpFileLine = fileLine;
                        if (isSectionName(fileLine)) {
                            sectionName = cleanSectionName(fileLine);

                        }else if ( !isCommentedString(fileLine) ) {
                            string parameterName = getKeyValueParameter(fileLine)[0];
                            string oldParameter = getKeyValueParameter(fileLine)[1];
                            string newParameter = getSectionByName(sectionName).getParameterByName(parameterName).getValue();
                            tmpFileLine = fileLine.Replace(oldParameter, newParameter);
                        }
                    
                        newListOfLines.Add(tmpFileLine);
                       
                    }
                    sr.Close();
                    System.IO.File.WriteAllLines(@tmpConfigFile, newListOfLines.ToArray());
                    System.IO.File.Delete(CONFIG_FILE);
                    System.IO.File.Move(tmpConfigFile, CONFIG_FILE);

                }
            } catch (Exception e) {
                Console.WriteLine("The file could not be write.");
                Console.WriteLine(e.Message);

            }
        
        }
       

    }
    
}
