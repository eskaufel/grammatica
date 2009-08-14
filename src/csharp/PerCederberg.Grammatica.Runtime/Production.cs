/*
 * Production.cs
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public License
 * as published by the Free Software Foundation; either version 3
 * of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free
 * Software Foundation, Inc., 59 Temple Place, Suite 330, Boston,
 * MA 02111-1307, USA.
 *
 * Copyright (c) 2003-2005 Per Cederberg. All rights reserved.
 */

using System.Collections.Generic;

namespace PerCederberg.Grammatica.Runtime {

    /**
     * A production node. This class represents a grammar production
     * (i.e. a list of child nodes) in a parse tree. The productions
     * are created by a parser, that adds children a according to a
     * set of production patterns (i.e. grammar rules).
     *
     * @author   Per Cederberg, <per at percederberg dot net>
     * @version  1.6
     */
    public class Production : Node {

        /**
         * The alternative used for this node.
         */
        private ProductionPatternAlternative alt;

        /**
         * The production pattern used for this production.
         */
        private ProductionPattern pattern;

        /**
         * The child nodes.
         */
        internal List<Node> children;

        /**
         * Creates a new production node.
         *
         * @param alt        the production pattern alternative
         */
        public Production(ProductionPatternAlternative alt) {
            this.alt = alt;
            this.pattern = alt.Pattern;
            this.children = new List<Node>();
        }

        /**
         * The node type id property (read-only). This value is set as
         * a unique identifier for each type of node, in order to
         * simplify later identification.
         *
         * @since 1.5
         */
        public override int Id {
            get {
                return pattern.Id;
            }
        }

        /**
         * The node name property (read-only).
         *
         * @since 1.5
         */
        public override string Name {
            get {
                return pattern.Name;
            }
        }

        /**
         * The child node count property (read-only).
         *
         * @since 1.5
         */
        public override int Count {
            get {
                return children.Count;
            }
        }

        /**
         * The child node index (read-only).
         *
         * @param index          the child index, 0 <= index < Count
         *
         * @return the child node found, or
         *         null if index out of bounds
         *
         * @since 1.5
         */
        public override Node this[int index] {
            get {
                if (index < 0 || index >= children.Count) {
                    return null;
                } else {
                    return (Node) children[index];
                }
            }
        }

        /**
         * Adds a child node. The node will be added last in the list of
         * children.
         *
         * @param child          the child node to add
         */
        public void AddChild(Node child) {
            // Set the parent if the child is not null.
            if (child != null) {
                child.SetParent(this);
            }

            // Add the child.
            children.Add(child);
        }

        /**
         * The production pattern alternative property (read-only).
         * This property contains the production pattern alternative
         * linked to this production.
         *
         * @since 1.6
         */
        public ProductionPatternAlternative Alternative {
            get {
                return alt;
            }
        }

        /**
         * The production pattern property (read-only). This property
         * contains the production pattern linked to this production.
         *
         * @since 1.5
         */
        public ProductionPattern Pattern {
            get {
                return pattern;
            }
        }

        /**
         * Returns the production pattern for this production.
         *
         * @return the production pattern
         *
         * @see #Pattern
         *
         * @deprecated Use the Pattern property instead.
         */
        public ProductionPattern GetPattern() {
            return Pattern;
        }

        /**
         * Checks if this node is synthetic.
         *
         * @return true if the node is synthetic, or false otherwise
         */
        public override bool IsSynthetic() {
            return pattern.Synthetic;
        }

        /**
         * Returns a string representation of this production.
         *
         * @return a string representation of this production
         */
        public override string ToString() {
            return pattern.Name + '(' + pattern.Id + ')';
        }
    }
}
