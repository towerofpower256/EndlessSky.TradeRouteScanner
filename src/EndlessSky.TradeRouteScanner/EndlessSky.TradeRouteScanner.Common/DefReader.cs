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
        public const char CHAR_QUOTE_QUOTE = '"';
        public const char CHAR_QUOTE_TILDE = '`';

        public ProgressEventSource ProgressEvents = new ProgressEventSource();
        

        public DefReader()
        {

        }

        public DefNode LoadDataFromFile(string filepath)
        {
            var rootNode = new DefNode();
            rootNode.Tokens.Add("FILE");
            rootNode.Tokens.Add(filepath);

            return LoadDataFromFile(filepath, rootNode);
        }

        public DefNode LoadDataFromFile(string filepath, DefNode rootNode)
        {
            using (var stream = new FileStream(filepath, FileMode.Open))
            {
                return LoadData(stream, rootNode);
            }
        }

        public DefNode LoadDataFromString(string s)
        {
            var rootNode = new DefNode();

            var bytes = Encoding.UTF8.GetBytes(s);
            var stream = new MemoryStream(bytes);
            return LoadData(stream, rootNode);
        }

        public DefNode LoadDataFromStream(Stream s)
        {
            var rootNode = new DefNode();

            return LoadData(s, rootNode);
        }

        public DefNode LoadData(Stream dataStream, DefNode rootNode)
        {
            var sr = new StreamReader(dataStream, UTF8Encoding.UTF8);

            int indentLevel = 0; // Indentation level
            Stack<DefNode> nodeStack = new Stack<DefNode>();
            Stack<int> indentStack = new Stack<int>();
            char c;
            StringBuilder tokenBuffer;

            // Add the root node
            nodeStack.Push(rootNode);
            indentStack.Push(-1); // Start with -1 in it

            // At the root level
            // Read through the lines of characters, until there are none left
            c = GetNextChar(sr);
            while (sr.Peek() >= 0)
            {
                indentLevel = 0; // Reset the indent level

                // Read through spaces
                while (c == CHAR_WHITESPACE_TAB)
                {
                    indentLevel++;
                    c = GetNextChar(sr); // keep reading
                }

                // Skip empty lines
                if (c == CHAR_NEWLINE)
                {
                    c = GetNextChar(sr);
                    continue;
                }
                    

                if (c == CHAR_COMMENT)
                {
                    // Is a comment line. Read until new line.
                    while (c != CHAR_NEWLINE)
                    {
                        // Read until newline
                        c = GetNextChar(sr);
                    }
                    continue; // Start reading line again
                }

                // Is a valid line.

                // Determine where in the node tree we are inserting this node, based on
                // whether it has more indentation that the previous node, less, or the same.
                // If the previous line's indentation level is equal or greater this row's indentation level,
                // then this row is not a child of the previous row. Keep going backwards in the stack until the same
                // indentation level is met.
                while (indentStack.Peek() >= indentLevel)
                {
                    indentStack.Pop();
                    nodeStack.Pop();
                }

                // Ready to read this node
                DefNode parent = nodeStack.Peek(); // Because the root node should be in there, there should ALWAYS be something in there

                // Read the line
                //var newNode = ReadLine(sr, c);
                var newDefNode = new DefNode();
                char quoteChar = Char.MinValue;

                // Loop for each token, or until the stream runs out
                while (sr.Peek() >= 0)
                {
                    // Reset some things
                    quoteChar = Char.MinValue;
                    tokenBuffer = new StringBuilder();

                    // If the next character is a whitespace, end of line
                    if (c == CHAR_NEWLINE)
                    {
                        break;
                    }

                    // Wait for the next non-whitespace character
                    if (Char.IsWhiteSpace(c))
                    {
                        // Don't care, next char
                        c = GetNextChar(sr);
                        continue;
                    }

                    // If there's a comment, do nothing
                    if (c == CHAR_COMMENT)
                    {
                        // Comment. Don't care about the rest of the line.
                        while (c != CHAR_NEWLINE)
                        {
                            c = GetNextChar(sr);
                        }
                        break;
                    }

                    // Read the token

                    // If the token starts with a quotation, remember what quotation was used, and ignore this character
                    if (c == CHAR_QUOTE_QUOTE || c == CHAR_QUOTE_TILDE)
                    {
                        quoteChar = c; // Remember what quote character was used

                        // ADvance a character
                        c = GetNextChar(sr);
                    }

                    // Read until the end of line, or an unquoted space, or the end of the quotation
                    while (c != CHAR_NEWLINE && ((quoteChar != Char.MinValue && c != quoteChar) || (quoteChar == Char.MinValue && c != ' ')))
                    {
                        tokenBuffer.Append(c);
                        c = GetNextChar(sr);
                    }

                    // Made it out here, end of token

                    if (tokenBuffer.Length > 0)
                        newDefNode.Tokens.Add(tokenBuffer.ToString());

                    if (c == quoteChar)
                        c = GetNextChar(sr); // Skip the trailing quote char

                    // Warn about unterminated quote
                    if (quoteChar != Char.MinValue && c == CHAR_NEWLINE)
                    {
                        // warn
                    }
                }

                // Done reading the line

                parent.ChildNodes.Add(newDefNode);

                // Remember where we are
                indentStack.Push(indentLevel);
                nodeStack.Push(newDefNode);
            }

            // Done reading
            return rootNode;
        }

        private char GetNextChar(StreamReader sr)
        {
            if (sr.EndOfStream) return '\n'; // For compatibility. End any lines gracefully
            else return (char)sr.Read(); ;
        }
    }
}
