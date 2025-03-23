window.getLocation = function () {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    resolve({
                        success: true,
                        latitude: position.coords.latitude,
                        longitude: position.coords.longitude
                    });
                },
                (error) => {
                    resolve({
                        success: false,
                        message: error.message
                    });
                }
            );
        } else {
            resolve({
                success: false,
                message: "Geolocation is not supported by this browser."
            });
        }
    });
};