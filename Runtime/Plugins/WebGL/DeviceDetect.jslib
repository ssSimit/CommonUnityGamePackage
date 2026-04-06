mergeInto(LibraryManager.library, {
    GetDeviceType: function() {
        var userAgent = navigator.userAgent;
        var deviceType = "Desktop";
        
        // Get screen dimensions
        var screenWidth = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
        var screenHeight = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;
        var maxDimension = Math.max(screenWidth, screenHeight);
        var minDimension = Math.min(screenWidth, screenHeight);
        var aspectRatio = maxDimension / minDimension;
        
        // Check for touch support
        var hasTouch = 'ontouchstart' in window || navigator.maxTouchPoints > 0 || navigator.msMaxTouchPoints > 0;
        
        // Mobile detection (phones)
        if (/iPhone|iPod|Android.*Mobile|webOS|BlackBerry|IEMobile|Opera Mini/i.test(userAgent)) {
            deviceType = "Mobile";
        }
        // Tablet detection - check multiple criteria
        else if (
            // iPad detection (including newer iPads that report as desktop)
            /iPad/i.test(userAgent) ||
            // Android tablets
            (/Android/i.test(userAgent) && !/Mobile/i.test(userAgent)) ||
            // Generic tablet detection based on screen size and touch
            (hasTouch && 
            minDimension >= 768 && maxDimension >= 1024 && 
            minDimension <= 1366 && maxDimension <= 2048 &&
            aspectRatio >= 1.2 && aspectRatio <= 1.8)
        ) {
            deviceType = "Tablet";
        }
        // Desktop fallback
        else {
            deviceType = "Desktop";
        }

        // Return numeric values
        switch(deviceType) {
            case "Mobile": return 1;
            case "Tablet": return 2;
            default: return 0; // Desktop
        }
    }
});
