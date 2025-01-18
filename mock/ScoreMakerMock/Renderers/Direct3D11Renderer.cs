using System;
using System.Windows.Forms;
using Vortice.Direct3D11;
using Vortice.DXGI;
using Vortice.Mathematics;
using SharpGen.Runtime;
using Vortice.Direct3D;

namespace ScoreMakerMock.Renderers
{
    public class Direct3D11Renderer : IDisposable
    {
        private ID3D11Device device;
        private ID3D11DeviceContext deviceContext;
        private IDXGISwapChain swapChain;
        private ID3D11RenderTargetView renderTargetView;
        private Control renderControl;
        private bool disposed = false;

        public Direct3D11Renderer(Control renderControl)
        {
            this.renderControl = renderControl;
            InitializeDirect3D();
        }

        private void InitializeDirect3D()
        {
            // デバイスとスワップチェーンの作成
            var swapChainDesc = new SwapChainDescription
            {
                BufferCount = 1,
                BufferDescription = new ModeDescription((uint)renderControl.ClientSize.Width, (uint)renderControl.ClientSize.Height, new Rational(60, 1), Format.R8G8B8A8_UNorm),
                BufferUsage = Usage.RenderTargetOutput,
                OutputWindow = renderControl.Handle,
                SampleDescription = new SampleDescription(1, 0),
                Windowed = true
            };

            FeatureLevel[] featureLevels = { FeatureLevel.Level_11_0 };

            D3D11.D3D11CreateDeviceAndSwapChain(
                null,
                DriverType.Hardware,
                DeviceCreationFlags.None,
                featureLevels,
                swapChainDesc,
                out swapChain,
                out device,
                out FeatureLevel? featureLevel,
                out deviceContext);

            // レンダーターゲットビューの作成
            using (var backBuffer = swapChain.GetBuffer<ID3D11Texture2D>(0))
            {
                renderTargetView = device.CreateRenderTargetView(backBuffer);
            }

            deviceContext.OMSetRenderTargets(renderTargetView);
            // ビューポートの設定
            var viewport = new Viewport(0, 0, renderControl.ClientSize.Width, renderControl.ClientSize.Height);
            deviceContext.RSSetViewports(new[] { viewport });
        }

        public void Render()
        {
            // 画面を青色でクリア
            deviceContext.ClearRenderTargetView(renderTargetView, new Color4(0.0f, 0.0f, 1.0f, 1.0f));

            // スワップチェーンを表示
            swapChain.Present(1, 0);
        }

        public void Dispose()
        {
            if (disposed) return;

            disposed = true;

            // リソースの解放
            renderTargetView.Dispose();
            swapChain.Dispose();
            deviceContext.Dispose();
            device.Dispose();
        }
    }
}
