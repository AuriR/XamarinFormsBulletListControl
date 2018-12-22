using System.Collections.Generic;
using System.IO;

namespace AurisIdeas.Controls
{
    public interface IBulletListControl
    {
        /// <summary>
        /// The list of strings to display.
        /// </summary>
        IEnumerable<string> Items { get; set; }

        /// <summary>
        /// Character to use as bullet. Setting a character will ignore any specified image.
        /// </summary>
        string BulletCharacter { get; set; }

        /// <summary>
        /// Image to use as bullet. If a character is set, that will ignore the image.
        /// </summary>
        Stream BulletImage { get; set; }

    }
}
