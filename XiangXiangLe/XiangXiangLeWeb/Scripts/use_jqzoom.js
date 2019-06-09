/*使用jqzoom*/
$(function(){
	$('.jqzoom').jqzoom({
		zoomType: 'standard',
		lens:true,
		preloadImages: false,
		alwaysOn:false,
		zoomWidth: 500,
		zoomHeight: 500,
		xOffset:20,
		yOffset:0,
		position:'right'
    });
});