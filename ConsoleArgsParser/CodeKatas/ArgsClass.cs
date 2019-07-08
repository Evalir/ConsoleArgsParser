using System;
using System.Collections.Generic;
using System.Text;

namespace ArgsConsole
{
    /// <summary>
    /// This class type exception only serves to indicate 
    /// when an invalid scheme has been sent.
    /// </summary>
    public class InvalidSchemeException : Exception { };
    /// <summary>
    /// This class type exception only serves to indicate 
    /// when no scheme has been sent.
    /// </summary>
    public class NoSchemeException : Exception { };
    /// <summary>
    /// This class type exception only serves to indicate 
    /// when an Invalid argument has been sent to the function.
    /// </summary>
    public class InvalidArgException : Exception { };


    public class ArgsClass
    {
        private Dictionary<string, string> schems = new Dictionary<string, string>();

        /// <summary>
        /// This void type function is only intended to add a scheme of 
        /// the type of data that you want to add.
        /// </summary>
        /// <typeparam name="S">
        ///This parameter is a generic type which will be defined according 
        ///to the type of variable value that you send.Example if int the 
        ///function will work for an int.
        ///</typeparam>
        /// <param name="scheme">
        /// what will define that variable will be what 
        /// data type will be the scheme
        /// </param>
        public void AddScheme<S>(Dictionary<string, S> scheme)
        {
            if (scheme.Count == 0 || scheme == null)
                throw new NoSchemeException();

            foreach (var command in scheme)
            {
                if ((command.Key.Length == 2 || command.Key[0] == '-') || (command.Key.Length == 3 && command.Key.Contains("--"))) { }
                //throw new InvalidSchemeException();
                else
                    throw new InvalidSchemeException();

                Type ParameterType = default(S).GetType();
                if (ParameterType == typeof(bool))
                    schems.Add(command.Key, "false");
                else
                    schems.Add(command.Key, "");

            }
        }
        /// <summary>
        /// This function aims to receive the schemes.and at the end returns 
        /// the scheme that was received but type Dictionary.
        /// </summary>
        /// <returns>
        /// This function returns the schemes that were requested 
        /// in a dictionary for which they were added.
        /// </returns>
        public Dictionary<string, string> GetSchemes()
        {
            return schems;
        }


        private string[] chain;

        /// <summary>
        /// This function does the same as the Other GeneralParsel what 
        /// the difference is that the arguments will be sent by string 
        /// strings. Then in the function the arguments will be parsed.
        /// </summary>
        /// <param name="args">
        ///This string type parameter will receive the argument as a string 
        ///and then be parceled by the function.
        ///</param>
        /// <returns>
        /// This function returns a fully parityed dictionary according 
        /// to the order established in the schemas given by the arguments.
        /// </returns>
        public Dictionary<string, string> GeneralSParse(string args)
        {
            var dict = new Dictionary<string, string>();
            if (args != null || args.Length == 0)
            {
                chain = args.Split(" ");
                int cant = chain.Length;
                for (int i = 0; i < cant; i++)
                {
                    if (schems.ContainsKey(chain[i]))
                    {
                        bool bollean = false;
                        if ((schems[chain[i]] == "false" || schems[chain[i]] == "true"))
                            bollean = true;
                        if (!bollean)
                        {
                            if (i == cant - 1)
                                throw new InvalidArgException();
                            if (i != cant - 1 && chain[i + 1][0] == '-')
                                throw new InvalidArgException();

                        }

                        if ((chain[i].Length == 2 && chain[i][0] == '-') || (chain[i].Length == 3 && chain[i].Contains("--"))) { }

                        else
                        {
                            throw new InvalidArgException();
                        }/*
                        if ((schems[chain[i]]=="false" || schems[chain[i]] == "true"))
                        {   //if(chain[i + 1][0] == '-')
                                throw new InvalidArgException();
                        }*/

                        //dict.Remove(chain[i]);
                        if (schems[chain[i]] == "false")
                            dict.Add(chain[i], "true");
                        else
                        {
                            string value = chain[i + 1].ToString();
                            dict.Add(chain[i], value);
                            i++;
                        }

                    }
                    else
                    {
                        throw new InvalidArgException();
                    }
                }
            }
            return dict;
        }

        /// <summary>
        /// This function does the same as the Other GeneralParsel 
        /// what the difference is that the argumetos will be sent by 
        /// arrangements of strings.Then in the function the arguments 
        /// will be parsed.according to the schemes added.
        /// </summary>
        /// <param name="args"> 
        /// This parameter what you receive is a string arrangement
        /// which will be split for this function.
        /// </param>
        /// <returns>
        /// This function returns a fully parityed dictionary according 
        /// to the order established in the schemas given by the arguments.
        /// </returns>
        public Dictionary<string, string> GeneralSParse(string[] args)
        {
            var dict = new Dictionary<string, string>();
            if (args != null || args.Length == 0)
            {
                int cant = chain.Length;
                for (int i = 0; i < cant; i++)
                {
                    if (schems.ContainsKey(chain[i]))
                    {
                        bool bollean = false;
                        if (schems[chain[i]] == "false" || schems[chain[i]] == "true")
                            bollean = true;
                        if (!bollean)
                        {
                            if (i == cant - 1)
                                throw new InvalidArgException();
                            if (i != cant - 1 && chain[i + 1][0] == '-')
                                throw new InvalidArgException();
                        }
                        if ((chain[i].Length != 2 && chain[i][0] != '-') || (chain[i].Length != 3 && chain[i].Contains("--")))
                            throw new InvalidArgException();
                        /*
                    if ((schems[chain[i]]=="false" || schems[chain[i]] == "true"))
                    {   //if(chain[i + 1][0] == '-')
                            throw new InvalidArgException();
                    }*/
                        dict.Remove(chain[i]);
                        if (schems[chain[i]] == "false")
                            dict.Add(chain[i], "true");
                        else
                        {
                            string value = chain[i + 1].ToString();
                            dict.Add(chain[i], value);
                            i++;
                        }

                    }
                    else
                        throw new InvalidArgException();
                }
            }
            return dict;
        }

        /// <summary>
        /// This function aims to receive a Scheme of Boolean type, 
        /// and will work with arguments equally.
        /// Which will be distrubuidos by means of the aggregated schemes.
        /// </summary>
        /// <param name="scheme"> 
        /// This parameter receives the scheme which must be 
        /// parityed to take out the flag.
        /// </param>
        /// <param name="args">
        /// This other parameter of type string will receive the arguments 
        /// that will be recognized by the scheme.
        /// </param>
        /// <returns>
        /// At the end, a dictionary returns with 
        /// the schemas in Boolean format.
        /// </returns>
        public Dictionary<string, bool> BoolArgs(string[] scheme, string args)
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
            if (args != null)
            {
                string[] chain = args.Split(" ");
                foreach (var item in chain)
                {
                    if (item.Length != 2 && item[0] != '-')
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
