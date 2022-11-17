#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform float u_time;

vec3 colorA = vec3(0.9137, 0.8353, 0.1412);
vec3 colorB = vec3(0.4431, 0.098, 0.6745);

void main() {
    vec3 color = vec3(0.0);

    //percantage of mixing
    float pct = fract(sin(u_time));

    // Mix uses pct (a value from 0-1) to
    // mix the two colors
    color = mix(colorA, colorB, pct);

    gl_FragColor = vec4(color,1.0);
}