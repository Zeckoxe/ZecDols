﻿// Copyright (c) 2019-2020 Faber Leonardo. All Rights Reserved. https://github.com/FaberSanZ
// This code is licensed under the MIT license (MIT) (http://opensource.org/licenses/MIT)

/*=============================================================================
	VertexPositionColor.cs
=============================================================================*/





using System.Numerics;
using Zeckoxe.Core;

namespace Zeckoxe.Graphics
{
    public struct VertexPositionColor
    {
        public VertexPositionColor(Vector3 position, Vector3 color)
        {
            Position = position;
            Color = color;
        }

        public Vector3 Position;

        public Vector3 Color;



        public static readonly int Size = Interop.SizeOf<VertexPositionColor>();


        public bool Equals(VertexPositionColor other)
        {
            return Position.Equals(other.Position) && Color.Equals(other.Color);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is VertexPositionColor v && Equals(v);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Position.GetHashCode();
                hashCode = (hashCode * 397) ^ Color.GetHashCode();
                return hashCode;
            }
        }

        public void FlipWinding()
        {
        }

        public static bool operator ==(VertexPositionColor left, VertexPositionColor right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VertexPositionColor left, VertexPositionColor right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("Position: {0}, Color: {1}", Position, Color);
        }
    }
}
