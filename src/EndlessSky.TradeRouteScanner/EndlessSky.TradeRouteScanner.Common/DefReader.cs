using System;
using System.IO;
using EndlessSky.TradeRouteScanner.Common.Models;
using System.Text;
using System.Collections.Generic;

namespace EndlessSky.TradeRouteScanner.Common
{
    // NOTES
    // Endless Sky uses its own format, based on levels of indentation. Similar to YAML, but isn't.
    // Code used by Endless Sky to read files: https://github.com/endless-sky/endless-sky/blob/393996ef9ba0a177c4d706b2d1518c843a79149e/source/DataFile.cpp

    // Is made up of nodes
    // Nodes can have child nodes
    // Nodes can have tokens
    // Tokens can be wrapped in quotation
    // E.g.
    // node token token token
    //     subnode token token
    //     subnode 
    //
    // E.g.
    // system "Delta Velorum"
    //     pos -740 90
    //     link Fala
    //     object
    //         sprite star/g0
    //         period 10

    /// <summary>
    /// Reader class for reading the Endless Sky definition files.    
    /// </summary>
    public class DefReader
    {
        public const char CHAR_WHITESPACE_TAB = '\t';
        public const char CHAR_WHITESPACE_SPACE = ' ';
        public const char CHAR_COMMENT = '#';
        public const char CHAR_NEWLINE = '\n';


        public DefReader()
        {

        }

        public DefNodeCollection LoadData(Stream dataStream)
        {
            var rootNodeCollection = new DefNodeCollection();
            var streamReader = new StreamReader(dataStream, UTF8Encoding.UTF8);
            uint currentLevel = 0;
            uint rowLevel = 0; // Indentation level
            Stack<DefNode> nodeStack = new Stack<DefNode>();
            DefNode currentNode;
            char c;
            bool isQuoted = false;
            char quoteChar = ' ';
            StringBuilder tokenBuffer;

            // At the root level
            // Read through the characters, until there are none left
            while (streamReader.Peek() >= 0)
            {
                c = (char)streamReader.Read();

                // Read through spaces
                if (c == CHAR_WHITESPACE_TAB)
                {
                    rowLevel++;
                    continue; // Read next char
                }

                // Skip empty lines
                if (c == CHAR_NEWLINE)
                    continue;

                if (c == CHAR_COMMENT)
                {
                    // Is a comment line. Read until new line.
                    while (!streamReader.EndOfStream && streamReader.Read() != CHAR_NEWLINE)
                    {
                        // Read until newline
                        continue;
                    }
                }

                // Is a valid line.

                var newNode = new DefNode();

                // Read the line
                while (c != CHAR_NEWLINE)
                {
                    tokenBuffer = new StringBuilder();

                    // If it's the start of a quotation, note that down and read the next character
                    if (!isQuoted && c == '"' || c == '`')
                    {
                        isQuoted = true;
                        quoteChar = c;
                        c = (char)streamReader.Read();
                        continue;
                    }

                    // If it's the end of the token,
                    // save this token and get ready to read another.
                    if (c == ' ' && !isQuoted)
                    {
                        newNode.Tokens.Add(tokenBuffer.ToString());
                        tokenBuffer = new StringBuilder();
                        c = (char)streamReader.Read();
                        continue;
                    }

                    // If it's the end of the quotation
                    if (isQuoted && c == quoteChar)
                    {
                        newNode.Tokens.Add(tokenBuffer.ToString());
                        tokenBuffer = new StringBuilder();
                        c = (char)streamReader.Read();
                        continue;
                    }


                    if (!isQuoted)

                    // Read the next char
                    c = (char)streamReader.Read();
                }
            }
        }
    }
}
