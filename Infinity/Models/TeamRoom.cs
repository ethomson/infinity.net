﻿using System;

namespace Infinity.Models
{
    /// <summary>
    /// A Team Room for chat.
    /// </summary>
    public class TeamRoom
    {
        /// <summary>
        /// The unique ID for this Team Room.
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        /// The name of this Team Room.
        /// </summary>
        public string Name { get; internal set; }
        
        /// <summary>
        /// The description for this Team Room.
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// The last message activity in the Team Room.
        /// </summary>
        public DateTime LastActivity { get; internal set; }

        /// <summary>
        /// Whether the Team Room is closed or not.
        /// </summary>
        public bool IsClosed { get; internal set; }

        /// <summary>
        /// The creator of the Team Room.
        /// </summary>
        public TeamRoomAuthor CreatedBy { get; internal set; }

        /// <summary>
        /// The date the Team Room was created.
        /// </summary>
        public DateTime CreatedDate { get; internal set; }

        /// <summary>
        /// Whether the current user has administrative
        /// permissions for the Team Room.
        /// </summary>
        public bool HasAdminPermissions { get; internal set; }

        /// <summary>
        /// Whether the current user has read and write permissions
        /// for the Team Room.
        /// </summary>
        public bool HasReadWritePermissions { get; internal set; }
    }
}
