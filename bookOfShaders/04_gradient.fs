#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14159265359

uniform vec2 u_resolution;
uniform float u_time;
uniform float u_mouse;


vec3 colorA = vec3(0.902, 0.4, 0.0667);
vec3 colorB = vec3(0.0196, 0.0196, 0.3608);
vec3 colorC = vec3(0.9843, 1.0, 0.0);

float plot (vec2 st, float pct){
    return smoothstep( pct - 0.01, pct, st.y) - smoothstep(pct, pct + 0.01, st.y);
}

void main()
{
    vec2 st = gl_FragCoord.xy/u_resolution.xy;
    vec3 color = vec3(0.0);

    vec3 pct = vec3(abs(0.9 * sin(st.y - u_time * 1.0)));
    float y = -st.x + 1.0;


    color = mix(colorA, colorB, pct);

    color = mix(color, vec3(1.0), plot(st, y));
    //color = mix(color, vec3(0.0,0.0,1.0), plot(st, pct.z));

    gl_FragColor = vec4(color, 1.0);

}