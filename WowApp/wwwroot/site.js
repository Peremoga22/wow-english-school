window.addEventListener("unhandledrejection", (e) => {
    console.warn("Unhandled rejection:", e.reason);
});
