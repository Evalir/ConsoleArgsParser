using System;
using System.Collections.Generic;
using System.Text;

namespace CodeKatas
{
    public class InvalidSchemeException : Exception { };
    public class NoSchemeException : Exception { };
    public class InvalidArgException : Exception { };


    public class ArgsClass<S>
    {   
        
        public bool IsValueType<T>(T obj)
        {
            return typeof(S).IsValueType;
        }

        public Dictionary<string, bool> ParseArgumentsWithSchema(string[] scheme, string args)
        {
            var dict = new Dictionary<string, bool>();

            if (scheme.Length == 0 || scheme == null)
                throw new NoSchemeException();

            foreach (string command in scheme)
            {
                if (command.Length != 2 || command[0] != '-')
                    throw new InvalidSchemeException();
                else
                {
                    dict.Add(command, false);
                }
            }
            if (args!=null)
            {
                string[] chain = args.Split(" ");
                foreach (var item in chain)
                {   
                    if(item.Length!=2 && item[0]!='-')
                        throw new InvalidArgException();

                    if (dict.ContainsKey(item))
                    {
                        dict.Remove(item);
                        dict.Add(item, true);
                    }
                    else
                    {
                        throw new InvalidArgException();
                    }
                    
                }
            }
            return dict;
        }
    }
}
