var OpenWindowPlugin = {
    openWindow: function(link)
    {
        var url = UTF8ToString(link);
        document.onmouseup = function()
        {
            console.log(url);
            var MyWindow = window.open("about: blank");
            MyWindow.document.body.appendChild(MyWindow.document.createElement('img')).src = url;
            document.onmouseup = null;
        }
    }
};
 
mergeInto(LibraryManager.library, OpenWindowPlugin);