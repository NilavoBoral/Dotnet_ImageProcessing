import React, { useEffect, useState } from 'react';

function App() {
  const [imageSrc, setImageSrc] = useState('');

  useEffect(() => {
    fetch('http://localhost:5273/ImageProcessor')
      .then(response => response.blob())
      .then(blob => {
        const objectUrl = URL.createObjectURL(blob);
        setImageSrc(objectUrl);
      });
  }, []);

  return (
    <div>
      {imageSrc && <img src={imageSrc} alt="image" />}
    </div>
  );
}

export default App;
