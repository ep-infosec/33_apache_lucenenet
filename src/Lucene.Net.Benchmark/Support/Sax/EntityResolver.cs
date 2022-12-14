// SAX entity resolver.
// http://www.saxproject.org
// No warranty; no copyright -- use this as you will.
// $Id: EntityResolver.java,v 1.10 2002/01/30 21:13:44 dbrownell Exp $

using System.IO;

namespace Sax
{
    /// <summary>
    /// Basic interface for resolving entities.
    /// </summary>
    /// <remarks>
    /// <em>This module, both source code and documentation, is in the
    /// Public Domain, and comes with<strong> NO WARRANTY</strong>.</em>
    /// See<a href='http://www.saxproject.org'>http://www.saxproject.org</a>
    /// for further information.
    /// <para/>
    /// If a SAX application needs to implement customized handling
    /// for external entities, it must implement this interface and
    /// register an instance with the SAX driver using the
    /// <see cref="IXMLReader.EntityResolver"/>
    /// property.
    /// <para/>
    /// The XML reader will then allow the application to intercept any
    /// external entities(including the external DTD subset and external
    /// parameter entities, if any) before including them.
    /// <para/>
    /// Many SAX applications will not need to implement this interface,
    /// but it will be especially useful for applications that build
    /// XML documents from databases or other specialised input sources,
    /// or for applications that use URI types other than URLs.
    /// <para/>
    /// The following resolver would provide the application
    /// with a special character stream for the entity with the system
    /// identifier "http://www.myhost.com/today":
    /// 
    /// <code>
    /// public class MyResolver : IEntityResolver 
    /// {
    ///     public InputSource ResolveEntity (string publicId, string systemId)
    ///     {
    ///         if (systemId.Equals("http://www.myhost.com/today", StringComparison.Ordinal))
    ///         {
    ///             // return a special input source
    ///             MyReader reader = new MyReader();
    ///             return new InputSource(reader);
    ///         }
    ///         else
    ///         {
    ///             // use the default behaviour
    ///             return null;
    ///         }
    ///     }
    /// }
    /// </code>
    /// <para/>
    /// The application can also use this interface to redirect system
    /// identifiers to local URIs or to look up replacements in a catalog
    /// (possibly by using the public identifier).
    /// </remarks>
    /// <author>David Megginson</author>
    /// <version>2.0.1 (sax2r2)</version>
    /// <since>SAX 1.0</since>
    /// <seealso cref="IXMLReader.EntityResolver"/>
    /// <seealso cref="InputSource"/>
    public interface IEntityResolver
    {
        /// <summary>
        /// Allow the application to resolve external entities.
        /// </summary>
        /// <remarks>
        /// The parser will call this method before opening any external
        /// entity except the top-level document entity.Such entities include
        /// the external DTD subset and external parameter entities referenced
        /// within the DTD(in either case, only if the parser reads external
        /// parameter entities), and external general entities referenced
        /// within the document element(if the parser reads external general
        /// entities).  The application may request that the parser locate
        /// the entity itself, that it use an alternative URI, or that it
        /// use data provided by the application(as a character or byte
        /// input stream).
        /// <para/>
        /// Application writers can use this method to redirect external
        /// system identifiers to secure and/or local URIs, to look up
        /// public identifiers in a catalogue, or to read an entity from a
        /// database or other input source(including, for example, a dialog
        /// box).  Neither XML nor SAX specifies a preferred policy for using
        /// public or system IDs to resolve resources.However, SAX specifies
        /// how to interpret any InputSource returned by this method, and that
        /// if none is returned, then the system ID will be dereferenced as
        /// a URL.
        /// <para/>
        /// If the system identifier is a URL, the SAX parser must
        /// resolve it fully before reporting it to the application.
        /// </remarks>
        /// <param name="publicId">The public identifier of the external entity
        /// being referenced, or null if none was supplied.</param>
        /// <param name="systemId">The system identifier of the external entity
        /// being referenced.</param>
        /// <returns>An InputSource object describing the new input source,
        /// or null to request that the parser open a regular
        /// URI connection to the system identifier.</returns>
        /// <exception cref="SAXException">Any SAX exception, possibly wrapping another exception.</exception>
        /// <exception cref="IOException">A .NET-specific IO exception, possibly the result of creating 
        /// a new <see cref="Stream"/> or <see cref="TextReader"/> for the <see cref="InputSource"/>.</exception>
        /// <seealso cref="InputSource"/>
        InputSource ResolveEntity(string publicId,
                           string systemId);
    }
}
