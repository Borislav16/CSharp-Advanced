﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldNames)
        {
            Type type = Type.GetType(classToInvestigate);

            FieldInfo[] fields = type.GetFields(BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            object classInstance = Activator.CreateInstance(type, new object[] { });

            foreach ( var field in fields.Where(f => fieldNames.Contains(f.Name)))
            {
                string name = field.Name;
                object value = field.GetValue(classInstance);
            
            }

            return sb.ToString();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            var type = Type.GetType(className);

            var fields = type
                .GetFields(BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static);


            var sb = new StringBuilder();

            foreach (var field in fields.Where(f => f.IsPrivate == false))
            {
                sb.AppendLine($"{field.Name} must be private!");
            }


            var nonPublicMethods = type.
                GetMethods(BindingFlags.NonPublic
                | BindingFlags.Instance);

            foreach (var method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} must be public!");
            }


            var publicMethods = type.
               GetMethods(BindingFlags.Public
               | BindingFlags.Instance);

            foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} must be private!");
            }


            return sb.ToString().Trim();

        }
        public string RevealPrivateMethods(string className)
        {
            var type = Type.GetType(className);

            var privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }


            return sb.ToString().Trim();
        }
        public string CollectGettersAndSetters(string investigatedClass)
        {
            var type = Type.GetType(investigatedClass);

            var allMethods = type.GetMethods(BindingFlags.Public
                     | BindingFlags.NonPublic
                     | BindingFlags.Instance
                     | BindingFlags.Static);

            var sb = new StringBuilder();

            foreach (var method in allMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in allMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();


        }
    }
}
