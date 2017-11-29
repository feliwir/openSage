﻿using SharpDX.Direct3D11;
using D3D11 = SharpDX.Direct3D11;

namespace LLGfx
{
    partial class DepthStencilBuffer : GraphicsDeviceChild
    {
        internal DepthStencilView DeviceDepthStencilView { get; private set; }

        private void PlatformConstruct(GraphicsDevice graphicsDevice, int width, int height, float clearValue)
        {
            var depthStencilBuffer = AddDisposable(new Texture2D(graphicsDevice.Device, new Texture2DDescription
            {
                ArraySize = 1,
                BindFlags = BindFlags.DepthStencil,
                CpuAccessFlags = CpuAccessFlags.None,
                Format = SharpDX.DXGI.Format.D32_Float,
                Height = height,
                MipLevels = 1,
                OptionFlags = ResourceOptionFlags.None,
                SampleDescription = new SharpDX.DXGI.SampleDescription(1, 0),
                Usage = D3D11.ResourceUsage.Default,
                Width = width
            }));

            DeviceDepthStencilView = AddDisposable(new DepthStencilView(graphicsDevice.Device, depthStencilBuffer));
        }
    }
}
