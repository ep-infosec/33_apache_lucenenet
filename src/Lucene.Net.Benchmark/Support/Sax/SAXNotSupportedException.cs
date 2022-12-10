﻿// SAXNotSupportedException.java - unsupported feature or value.
// http://www.saxproject.org
// Written by David Megginson
// NO WARRANTY!  This class is in the Public Domain.
// $Id: SAXNotSupportedException.java,v 1.7 2002/01/30 21:13:48 dbrownell Exp $

using System;
#if FEATURE_SERIALIZABLE_EXCEPTIONS
using System.Runtime.Serialization;
#endif

namespace Sax
{
    /// <summary>
    /// Exception class for an unsupported operation.
    /// </summary>
    /// <remarks>
    /// <em>This module, both source code and documentation, is in the
    /// Public Domain, and comes with<strong> NO WARRANTY</strong>.</em>
    /// See<a href='http://www.saxproject.org'>http://www.saxproject.org</a>
    /// for further information.
    /// <para/>
    /// An XMLReader will throw this exception when it recognizes a
    /// feature or property identifier, but cannot perform the requested
    /// operation(setting a state or value).  Other SAX2 applications and
    /// extensions may use this class for similar purposes.
    /// </remarks>
    /// <since>SAX 2.0</since>
    /// <author>David Megginson</author>
    /// <version>2.0.1 (sax2r2)</version>
    /// <seealso cref="SAXNotRecognizedException"/>
    // LUCENENET: It is no longer good practice to use binary serialization. 
    // See: https://github.com/dotnet/corefx/issues/23584#issuecomment-325724568
#if FEATURE_SERIALIZABLE_EXCEPTIONS
    [Serializable]
#endif
    public class SAXNotSupportedException : SAXException
    {
        /// <summary>
        /// Construct a new exception with no message.
        /// </summary>
        public SAXNotSupportedException()
            : base()
        {
        }

        /// <summary>
        /// Construct a new exception with the given message.
        /// </summary>
        /// <param name="message">The text message of the exception.</param>
        public SAXNotSupportedException(string message)
            : base(message)
        {
        }

#if FEATURE_SERIALIZABLE_EXCEPTIONS
        /// <summary>
        /// Initializes a new instance of this class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected SAXNotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
