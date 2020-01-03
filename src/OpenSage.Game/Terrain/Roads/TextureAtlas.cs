﻿using System.Collections.Generic;
using System.Numerics;
using OpenSage.Mathematics;

namespace OpenSage.Terrain.Roads
{
    internal class TextureAtlas
    {
        // The actual texture coordinates depend on the RoadTemplate's RoadWidthInTexture,
        // so we create and cache one instance per width.
        private static readonly IDictionary<float, TextureAtlas> TextureAtlasCache = new Dictionary<float, TextureAtlas>();

        // The default road width in texture space.
        private const float UnscaledRoadWidth = 0.25f;

        // The length of the incoming roads in T and X crossings in texture space.
        private const float IncomingRoadStubLength = 0.004f;

        // The length from the center to the endpoint of the incoming roads in T and X crossings in texture space. 
        private const float LengthToIncomingRoad = UnscaledRoadWidth / 2 + IncomingRoadStubLength;

        // There are 3x3 tiles in a road texture, so a half tile is 1/6 = 0.1666...,
        // but the calculations are based on the rounded number.
        private const float HalfTileSize = 0.166f;

        private IDictionary<RoadTextureType, TextureCoordinates> _coordinates;

        public TextureCoordinates this[RoadTextureType roadType] => _coordinates[roadType];

        private TextureAtlas(float roadWidthInTexture)
        {
            var roadWidth = UnscaledRoadWidth * roadWidthInTexture;
            var halfRoadWidth = roadWidth / 2;

            _coordinates = new Dictionary<RoadTextureType, TextureCoordinates>();

            _coordinates.Add(
                RoadTextureType.Straight,
                TextureCoordinates.LeftTopRightBottom(
                    0f,
                    TileCenter(0) - halfRoadWidth,
                    1f,
                    TileCenter(0) + halfRoadWidth));

            _coordinates.Add(
                RoadTextureType.TCrossing,
                TextureCoordinates.LeftTopRightBottom(
                    TileCenter(2) - halfRoadWidth,
                    TileCenter(1) - LengthToIncomingRoad,
                    TileCenter(2) + LengthToIncomingRoad,
                    TileCenter(1) + LengthToIncomingRoad));

            _coordinates.Add(
                RoadTextureType.XCrossing,
                TextureCoordinates.LeftTopRightBottom(
                    TileCenter(2) - LengthToIncomingRoad,
                    TileCenter(2) - LengthToIncomingRoad,
                    TileCenter(2) + LengthToIncomingRoad,
                    TileCenter(2) + LengthToIncomingRoad));

            _coordinates.Add(
                RoadTextureType.AsymmetricYCrossing,
                TextureCoordinates.LeftTopWidthHeight(
                    0.395f - halfRoadWidth,
                    0.645f,
                    1.2f * UnscaledRoadWidth + halfRoadWidth,
                    0.335f));

            _coordinates.Add(
                RoadTextureType.BroadCurve,
                TextureCoordinates.Curve(
                    TileCenter(0),
                    halfRoadWidth,
                    MathUtility.ToRadians(30)));

            // TODO: TightCurve, SymmetricY, Join
        }

        /// <summary>
        /// Returns the offset of the center point of a tile in texture space.
        /// </summary>
        /// <param name="index">The tile index (0-2).</param>
        private float TileCenter(int index) => ((2 * index) + 1) * HalfTileSize;

        public static TextureAtlas ForRoadWidth(float roadWidthInTexture)
        {
            if (!TextureAtlasCache.TryGetValue(roadWidthInTexture, out var atlas))
            {
                atlas = new TextureAtlas(roadWidthInTexture);
                TextureAtlasCache.Add(roadWidthInTexture, atlas);
            }

            return atlas;
        }
    }

    internal class TextureCoordinates
    {
        public TextureCoordinates(Vector2 topLeft, Vector2 topRight, Vector2 bottomLeft, Vector2 bottomRight)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }

        public Vector2 TopLeft { get; }
        public Vector2 TopRight { get; }
        public Vector2 BottomLeft { get; }
        public Vector2 BottomRight { get; }

        public static TextureCoordinates LeftTopWidthHeight(float left, float top, float width, float height)
        {
            return new TextureCoordinates(
                new Vector2(left, top),
                new Vector2(left + width, top),
                new Vector2(left, top + height),
                new Vector2(left + width, top + height));
        }

        public static TextureCoordinates LeftTopRightBottom(float left, float top, float right, float bottom)
        {
            return new TextureCoordinates(
                new Vector2(left, top),
                new Vector2(right, top),
                new Vector2(left, bottom),
                new Vector2(right, bottom));
        }

        public static TextureCoordinates Curve(float y, float halfRoadWidth, float angle)
        {
            var topLeft = new Vector2(0, y - halfRoadWidth);
            var bottomLeft = new Vector2(0, y + halfRoadWidth);

            var radius = 10f / 3f * halfRoadWidth;
            var center = new Vector2(0, y - radius);
            var topRight = Vector2Utility.RotateAroundPoint(center, topLeft, angle);
            var bottomRight = Vector2Utility.RotateAroundPoint(center, bottomLeft, angle);

            return new TextureCoordinates(
                topLeft,
                topRight,
                bottomLeft,
                bottomRight);
        }
    }
}
