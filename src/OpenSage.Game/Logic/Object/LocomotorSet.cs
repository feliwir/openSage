﻿using System;
using System.Collections.Generic;
using System.IO;
using OpenSage.Data.Sav;

namespace OpenSage.Logic.Object
{
    public sealed class LocomotorSet
    {
        private readonly GameObject _gameObject;
        private readonly List<Locomotor> _locomotors;
        private Surfaces _surfaces;

        public LocomotorSet(GameObject gameObject)
        {
            _gameObject = gameObject;
            _locomotors = new List<Locomotor>();
        }

        public void Initialize(LocomotorSetTemplate locomotorSetTemplate)
        {
            _surfaces = Surfaces.None;

            foreach (var locomotorTemplateReference in locomotorSetTemplate.Locomotors)
            {
                var locomotorTemplate = locomotorTemplateReference.Value;

                _locomotors.Add(new Locomotor(
                    _gameObject,
                    locomotorTemplate,
                    locomotorSetTemplate.Speed));

                _surfaces |= locomotorTemplate.Surfaces;
            }
        }

        public void Reset()
        {
            _locomotors.Clear();
        }

        public Locomotor GetLocomotorForSurfaces(Surfaces surfaces)
        {
            foreach (var locomotor in _locomotors)
            {
                if ((locomotor.LocomotorTemplate.Surfaces & surfaces) != 0)
                {
                    return locomotor;
                }
            }
            return _locomotors[0];
        }

        public Locomotor GetLocomotor(string locomotorTemplateName)
        {
            foreach (var locomotor in _locomotors)
            {
                if (locomotor.LocomotorTemplate.Name == locomotorTemplateName)
                {
                    return locomotor;
                }
            }

            throw new InvalidOperationException();
        }

        internal void Load(SaveFileReader reader)
        {
            reader.ReadVersion(1);

            var numLocomotorTemplates = reader.ReadUInt16();
            for (var i = 0; i < numLocomotorTemplates; i++)
            {
                var locomotorTemplateName = reader.ReadAsciiString();

                var locomotorTemplate = _gameObject.GameContext.AssetLoadContext.AssetStore.LocomotorTemplates.GetByName(locomotorTemplateName);

                var locomotor = new Locomotor(_gameObject, locomotorTemplate, 100);

                locomotor.Load(reader);

                _locomotors.Add(locomotor);
            }

            _surfaces = reader.ReadEnumFlags<Surfaces>();
            
            var unknownBool1 = reader.ReadBoolean();
            if (unknownBool1 != false)
            {
                throw new InvalidDataException();
            }
        }
    }
}
