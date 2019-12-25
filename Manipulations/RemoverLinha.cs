using System;
using System.Collections.Generic;
using System.Text;
using Manipulations;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Manipulations
{
    class RemoverLinha
    {

        public static void RemoverLinhaSelecionada(string name)
        {

            string Arquivo = Verificacoes.Path.ToString() + Verificacoes.Files.ToString();
            string ProcurarTexto = name;
            string TextoAntigo;
            string valorNulo = "";
            StreamReader sr = File.OpenText(Arquivo);
            while ((TextoAntigo = sr.ReadLine()) != null)
            {
                if (!TextoAntigo.Contains(ProcurarTexto))
                {
                    valorNulo += TextoAntigo + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText(Arquivo, valorNulo);

            
        }
    }
}


