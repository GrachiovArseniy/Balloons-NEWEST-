﻿using System.Collections.Generic;

namespace Balloons.Model
{
    public class FieldBorder : IUpdateable
    {
        public FieldBorder(float downBorder)
        {
            _downBorder = downBorder;
        }

        private readonly List<Transformable> _entities = new List<Transformable>();
        private readonly float _downBorder;

        internal void AddEntity(Transformable entity)
        {
            _entities.Add(entity);
        }

        internal override void Update(float deltaTime)
        {
            foreach (var entity in _entities)
            {
                if (entity.Position.Y <= _downBorder)
                {
                    entity.MakeAbility();
                    entity.Remove();
                    _entities.Remove(entity);
                }
            }
        }

        public void DestroyAll()
        {
            _entities.ForEach(i => i.Remove());
        }
    }
}