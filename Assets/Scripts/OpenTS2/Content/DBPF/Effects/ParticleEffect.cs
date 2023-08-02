﻿using OpenTS2.Content.DBPF.Effects.Types;
using OpenTS2.Files.Formats.DBPF.Types;
using OpenTS2.Files.Utils;
using UnityEngine;
using Collider = OpenTS2.Content.DBPF.Effects.Types.Collider;

namespace OpenTS2.Content.DBPF.Effects
{
    /// <summary>
    /// This giant structure is how the game stores effects. Ideally we should only do this for now
    /// until we can split off things like "size" and "rotation" with all their different fields
    /// into different sub-types.
    /// </summary>
    public readonly struct ParticleEffect : IBaseEffect
    {
        public readonly ulong Flags;

        public readonly ParticleLife Life;

        public readonly ParticleEmission Emission;
        public readonly float RateSpeedScale;

        public readonly ParticleSize Size;

        public readonly Vector3 RotateAxis;
        public readonly float RotateOffsetX;
        public readonly float RotateOffsetY;
        public readonly FloatCurve RotateCurveX;
        public readonly FloatCurve RotateCurveY;

        public readonly ParticleColor Color;
        public readonly ParticleDrawing Drawing;

        public readonly float Screw;

        public readonly Wiggle[] Wiggles;

        public readonly ParticleBloom Bloom;

        public readonly Collider[] Colliders;

        public readonly ParticleTerrainInteraction TerrainInteraction;

        public readonly Vector2 RandomWalkDelay;
        public readonly Vector2 RandomWalkStrength;
        public readonly float RandomWalkTurnX;
        public readonly float RandomWalkTurnY;

        public ParticleEffect(ulong flags, ParticleLife life, ParticleEmission emission, float rateSpeedScale,
            ParticleSize size, Vector3 rotateAxis,
            float rotateOffsetX, float rotateOffsetY, FloatCurve rotateCurveX, FloatCurve rotateCurveY,
            ParticleColor color, ParticleDrawing drawing, float screw, Wiggle[] wiggles, ParticleBloom bloom,
            Collider[] colliders,
            ParticleTerrainInteraction terrainInteraction, Vector2 randomWalkDelay,
            Vector2 randomWalkStrength, float randomWalkTurnX, float randomWalkTurnY)
        {
            Flags = flags;
            Life = life;
            Emission = emission;
            RateSpeedScale = rateSpeedScale;
            Size = size;
            RotateAxis = rotateAxis;
            RotateOffsetX = rotateOffsetX;
            RotateOffsetY = rotateOffsetY;
            RotateCurveX = rotateCurveX;
            RotateCurveY = rotateCurveY;
            Color = color;
            Drawing = drawing;
            Screw = screw;
            Wiggles = wiggles;
            Bloom = bloom;
            Colliders = colliders;
            TerrainInteraction = terrainInteraction;
            RandomWalkDelay = randomWalkDelay;
            RandomWalkStrength = randomWalkStrength;
            RandomWalkTurnX = randomWalkTurnX;
            RandomWalkTurnY = randomWalkTurnY;
        }
    }

    public struct ParticleLife
    {
        public Vector2 Life { get; }
        public float LifePreRoll { get; }

        public ParticleLife(Vector2 life, float lifePreRoll)
        {
            Life = life;
            LifePreRoll = lifePreRoll;
        }
    }

    public struct ParticleEmission
    {
        public Vector2 RateDelay { get; }
        public Vector2 RateTrigger { get; }

        public BoundingBox EmitDirection { get; }
        public Vector2 EmitSpeed { get; }
        public BoundingBox EmitVolume { get; }
        public float EmitTorusWidth { get; }

        public FloatCurve RateCurve { get; }
        public float RateCurveTime { get; }
        public uint RateCurveCycles { get; }

        public ParticleEmission(Vector2 rateDelay, Vector2 rateTrigger, BoundingBox emitDirection, Vector2 emitSpeed,
            BoundingBox emitVolume, float emitTorusWidth, FloatCurve rateCurve, float rateCurveTime,
            uint rateCurveCycles)
        {
            RateDelay = rateDelay;
            RateTrigger = rateTrigger;
            EmitDirection = emitDirection;
            EmitSpeed = emitSpeed;
            EmitVolume = emitVolume;
            EmitTorusWidth = emitTorusWidth;
            RateCurve = rateCurve;
            RateCurveTime = rateCurveTime;
            RateCurveCycles = rateCurveCycles;
        }
    }

    public struct ParticleSize
    {
        public FloatCurve SizeCurve { get; }
        public float SizeVary { get; }

        public FloatCurve AspectCurve { get; }
        public float AspectVary { get; }

        public ParticleSize(FloatCurve sizeCurve, float sizeVary, FloatCurve aspectCurve, float aspectVary)
        {
            SizeCurve = sizeCurve;
            SizeVary = sizeVary;
            AspectCurve = aspectCurve;
            AspectVary = aspectVary;
        }
    }

    public struct ParticleColor
    {
        public FloatCurve AlphaCurve { get; }
        public float AlphaVary { get; }

        public Vector3[] Colors { get; }
        public Vector3 ColorVary { get; }

        public ParticleColor(FloatCurve alphaCurve, float alphaVary, Vector3[] colors, Vector3 colorVary)
        {
            AlphaCurve = alphaCurve;
            AlphaVary = alphaVary;
            Colors = colors;
            ColorVary = colorVary;
        }
    }

    public struct ParticleDrawing
    {
        public string MaterialName { get; }
        public byte TileCountU { get; }
        public byte TileCountV { get; }

        public byte ParticleAlignmentType { get; }
        public byte ParticleDrawType { get; }

        public float Layer { get; }
        public float FrameSpeed { get; }
        public byte FrameStart { get; }
        public byte FrameCount { get; }

        public ParticleDrawing(string materialName, byte tileCountU, byte tileCountV, byte particleAlignmentType,
            byte particleDrawType, float layer, float frameSpeed, byte frameStart, byte frameCount)
        {
            MaterialName = materialName;
            TileCountU = tileCountU;
            TileCountV = tileCountV;
            ParticleAlignmentType = particleAlignmentType;
            ParticleDrawType = particleDrawType;
            Layer = layer;
            FrameSpeed = frameSpeed;
            FrameStart = frameStart;
            FrameCount = frameCount;
        }
    }

    public struct ParticleTerrainInteraction
    {
        public float Bounce { get; }
        public float RepelHeight { get; }
        public float RepelStrength { get; }
        public float RepelScout { get; }
        public float RepelVertical { get; }
        public float KillHeight { get; }
        public float TerrainDeathProbability { get; }
        public float WaterDeathProbability { get; }

        public ParticleTerrainInteraction(float bounce, float repelHeight, float repelStrength, float repelScout,
            float repelVertical, float killHeight, float terrainDeathProbability, float waterDeathProbability)
        {
            Bounce = bounce;
            RepelHeight = repelHeight;
            RepelStrength = repelStrength;
            RepelScout = repelScout;
            RepelVertical = repelVertical;
            KillHeight = killHeight;
            TerrainDeathProbability = terrainDeathProbability;
            WaterDeathProbability = waterDeathProbability;
        }
    }

    public struct ParticleBloom
    {
        public byte AlphaRate { get; }
        public byte Alpha { get; }
        public byte SizeRate { get; }
        public byte Size { get; }

        public ParticleBloom(byte alphaRate, byte alpha, byte sizeRate, byte size)
        {
            AlphaRate = alphaRate;
            Alpha = alpha;
            SizeRate = sizeRate;
            Size = size;
        }
    }

    // These are methods common to both Particle and MetaParticles.
    #region Particle and MetaParticle common readers
    public static class ParticleHelper
    {
        internal static ParticleLife ReadParticleLife(IoBuffer reader)
        {
            return new ParticleLife(life: Vector2Serializer.Deserialize(reader), lifePreRoll: reader.ReadFloat());
        }

        internal static ParticleEmission ReadParticleEmission(IoBuffer reader, ushort version, bool isMetaParticle)
        {
            // Rate and emission.
            var rateDelay = Vector2Serializer.Deserialize(reader);
            var rateTrigger = Vector2Serializer.Deserialize(reader);

            var emitDirectionBBox = BoundingBox.Deserialize(reader);
            var emitSpeed = Vector2Serializer.Deserialize(reader);
            var emitVolumeBBox = BoundingBox.Deserialize(reader);
            var emitTorusWidth = -1.0f;
            if ((isMetaParticle && version > 1) || (!isMetaParticle && version > 2))
            {
                emitTorusWidth = reader.ReadFloat();
            }

            var rateCurve = FloatCurve.Deserialize(reader);
            var rateCurveTime = reader.ReadFloat();
            // Yup, for some reason even though it's the same field, particles read as a short whereas metaparticles
            // read it as an int...
            var rateCurveCycles = isMetaParticle switch
            {
                true => reader.ReadUInt32(),
                false => reader.ReadUInt16(),
            };

            return new ParticleEmission(rateDelay, rateTrigger, emitDirectionBBox, emitSpeed, emitVolumeBBox,
                emitTorusWidth, rateCurve, rateCurveTime, rateCurveCycles);
        }

        internal static ParticleSize ReadParticleSize(IoBuffer reader)
        {
            return new ParticleSize(
                sizeCurve: FloatCurve.Deserialize(reader), sizeVary: reader.ReadFloat(),
                aspectCurve: FloatCurve.Deserialize(reader), aspectVary: reader.ReadFloat());
        }

        internal static ParticleBloom ReadParticleBloom(IoBuffer reader)
        {
            return new ParticleBloom(alphaRate: reader.ReadByte(), alpha: reader.ReadByte(),
                sizeRate: reader.ReadByte(), size: reader.ReadByte());
        }

        internal static ParticleTerrainInteraction ReadParticleTerrainInteraction(IoBuffer reader)
        {
            return new ParticleTerrainInteraction(
                bounce: reader.ReadFloat(),
                repelHeight: reader.ReadFloat(),
                repelStrength: reader.ReadFloat(),
                repelScout: reader.ReadFloat(),
                repelVertical: reader.ReadFloat(),
                killHeight: reader.ReadFloat(),
                terrainDeathProbability: reader.ReadFloat(), waterDeathProbability: reader.ReadFloat()
            );
        }
    }
    #endregion
}