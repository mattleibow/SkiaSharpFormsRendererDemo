# SkiaSharp Xamarin.Forms Custom Renderer

A simple demonstration app to show an example of a SkiaSharp custom renderer.

There are a few things needed when creating a renderer. First, in the core project, 
create the new view type which will inherit either from 
[`SKCanvasView`](https://developer.xamarin.com/api/type/SkiaSharp.Views.Forms.SKCanvasView) 
or [`SKGLView`](https://developer.xamarin.com/api/type/SkiaSharp.Views.Forms.SKGLView):

```csharp
public class TouchCanvasView : SKCanvasView
{
}
```

Then we can add it to the XAML (note the new `xmlns:custom` attribute):

```xml
<ContentPage ... xmlns:custom="clr-namespace:CustomRendererDemo;assembly=CustomRendererDemo">
    <custom:TouchCanvasView />
</ContentPage>
```

Next, we have to create the platform renderers. To do this, we create the renderer 
type and register it using the `[ExportRenderer]` attribute. The new renderer should 
inherit either from `SKCanvasViewRenderer` or `SKGLViewRenderer`:

```csharp
// register this renderer with Xamarin.Forms
[assembly: ExportRenderer(typeof(TouchCanvasView), typeof(TouchCanvasViewRenderer))]

public class TouchCanvasViewRenderer : SKCanvasViewRenderer
{
    protected override void OnElementChanged(ElementChangedEventArgs<SKCanvasView> e)
    {
        if (Control != null)
        {
            // clean up old native control
        }

        if (Element != null)
        {
            var oldTouchCanvas = (TouchCanvasView)Element;

            // do clean up old element
        }

        base.OnElementChanged(e);

        if (Control != null)
        {
            // set up new native control
        }

        if (e.NewElement != null)
        {
            var newTouchCanvas = (TouchCanvasView)Element;

            // set up new element
        }
    }
}
```
