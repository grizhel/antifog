import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import "@ant-design/v5-patch-for-react-19";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<App />);

// unstableSetRender((node, container) => {
//   container._reactRoot ||= createRoot(container);
//   const root = container._reactRoot;
//   root.render(node);
//   return async () => {
//     await new Promise((resolve) => setTimeout(resolve, 0));
//     root.unmount();
//   };
// });
