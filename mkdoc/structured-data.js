document.addEventListener("DOMContentLoaded", function () {
    var jsonLdData = {
        "@context": "https://schema.org",
        "@type": "WebPage",
        "name": document.title,
        "url": window.location.href
    };

    var scriptTag = document.createElement("script");
    scriptTag.type = "application/ld+json";
    scriptTag.textContent = JSON.stringify(jsonLdData);
    document.head.appendChild(scriptTag);
});
