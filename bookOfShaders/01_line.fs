/*From the book of shaders: https://thebookofshaders.com/05/
**
**
*/

#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

// Plot a line on Y using a value between 0.0-1.0
float plot(vec2 st) {    
    //returns about 1.0 when abs(st.y-st.x) <= 0.02 (making it smooth)
    return smoothstep(0.02, 0.0, abs(st.y - st.x));
}

void main() {
	vec2 st = gl_FragCoord.xy/u_resolution;

    float y = st.x;
    //mouse coordinates normalized from 0.0 to 1.0
    vec2 normalizedMouse = u_mouse/u_resolution;

    //plots the background, with green value changing based on the mouse position on the y axis
    vec3 color = vec3(y, normalizedMouse.y, 0.0);

    // Plot a line, red changes based on the mouse position on the x axis
    float pct = plot(st);
    color = (1.0-pct)*color+pct*vec3(normalizedMouse.x, 0.8667, 0.0);

	gl_FragColor = vec4(color,1.0);
}
