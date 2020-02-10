#define TERSE
//#define VERBOSE

using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Skill_2._5_Reflection
{
    class Program
    {
        [Conditional("VERBOSE"), Conditional("TERSE")]
        static void reportHeader()
        {
            Console.WriteLine("This is the header for the report.");
        }

        [Conditional("VERBOSE")]
        static void verboseReport()
        {
            Console.WriteLine("This is output from the verbose report.");
        }

        [Conditional("TERSE")]
        static void terseReport()
        {
            Console.WriteLine("This is output from the terse report.");
        }

        class Pessoa
        {
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            reportHeader();
            terseReport();
            verboseReport();

            System.Type type;

            Pessoa p = new Pessoa();
            type = p.GetType();

            foreach (MemberInfo member in type.GetMembers())
            {
                Console.WriteLine($"{member.ToString()} \n");
            }

            MethodInfo setMethod = type.GetMethod("set_Name");
            setMethod.Invoke(p, new object[] { "Fred" });

            Console.WriteLine($"Name: {p.Name}");

            /* CRIANDO CLASSE EM TEMPO DE EXECUÇÃO. */
            CodeCompileUnit compuleUnit = new CodeCompileUnit();

            //create a namespace to hold the types we are going to create
            CodeNamespace personnelNameSpace = new CodeNamespace("Personnel");

            //Import the system namespace
            personnelNameSpace.Imports.Add(new CodeNamespaceImport("System"));

            // Create a Person class
            CodeTypeDeclaration personClass = new CodeTypeDeclaration("Person");
            personClass.IsClass = true;
            personClass.TypeAttributes = System.Reflection.TypeAttributes.Public;

            // Add the Person class to personnelNamespace
            personnelNameSpace.Types.Add(personClass);

            // create a field to hold the name of a person
            CodeMemberField nameField = new CodeMemberField("String", "name");
            nameField.Attributes = MemberAttributes.Private;

            // add the name field to the Person class
            personClass.Members.Add(nameField);

            // add the namespace to the document
            compuleUnit.Namespaces.Add(personnelNameSpace);

            /* CRIANDO DOCUMENTO DA CLASSE */

            // Now we need to send our document somewhere
            // Create a provider to parse the document
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            // Give the provider somewhere to send the parsed output
            StringWriter s = new StringWriter();

            // Set some options for the parse - we can use the defaults
            CodeGeneratorOptions options = new CodeGeneratorOptions();

            // Generate the C# source from the CodeDOM
            provider.GenerateCodeFromCompileUnit(compuleUnit, s, options);

            // Close the output stream
            s.Close();

            // Print the c# output
            Console.WriteLine(s.ToString());


            Console.ReadKey();
        }
    }

    internal class CondeCompineUnit
    {
        public CondeCompineUnit()
        {
        }
    }
}
