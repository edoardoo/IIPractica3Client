using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3Client {
    //es la estructura de  los parametros
    //ATTENCION falta verifica de tipo
    public class Parameter {
        private string key;
        private string value;
        public Parameter( string key, string value) {
            this.key = key;
            this.value = value;
        }
        public void setKey( string key ) {
            this.key = key;
        }
        public string getKey() {
            return this.key;
        }

        public void setValue(string value) {
            this.value = value;
        }
        public string getValue() {
            return this.value;
        }
    }
}
