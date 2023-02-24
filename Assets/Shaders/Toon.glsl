Shader "Toon Shader for this game" 
{
    Properties 
    {
        Colr ("Diffuse Color", Color) = (1, 1, 1, 1)

        UnlitColor ("Unlit Diffuse Color", Color) = (0.5, 0.5, 0.5, 1) 
        
        DiffuseThreshold ("Threshold for Diffuse Colors", Range(0, 1)) = 0.1 
        
        OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        
        LitOutlineThickness ("Lit Outline Thickness", Range(0, 1)) = 0.1
        
        UnlitOutlineThickness ("Unlit Outline Thickness", Range(0, 1)) = 0.4
        
        SpecColor ("Specular Color", Color) = (1, 1, 1, 1) 
        
        Shininess ("Shininess", Float) = 100
    }

    SubShader
    {
        Pass
        {
            Tags
            {
                "LightMode" = "ForwardBase"
            }

            GLSLPROGRAM

            uniform vec4 Colr; 
        
            uniform vec4 UnlitColor;
        
            uniform float DiffuseThreshold;
        
            uniform vec4 OutlineColor;
        
            uniform float LitOutlineThickness;
        
            uniform float UnlitOutlineThickness;
        
            uniform vec4 SpecColor; 
        
            uniform float Shininess;

            uniform vec3 WorldSpaceCameraPos; 

            uniform mat4 Object2World;

            uniform mat4 World2Object;
            
            uniform vec4 WorldSpaceLightPos0; 

            uniform vec4 LightColor0; 

            varying vec4 position; 

            varying vec3 varyingNormalDirection; 

            #ifdef VERTEX

            void main()
            {                                
                mat4 modelMatrix = _Object2World;

                mat4 modelMatrixInverse = World2Object;

                position = modelMatrix * gl_Vertex;
                
                varyingNormalDirection = normalize(vec3(vec4(gl_Normal, 0.0) 
                * modelMatrixInverse));

                gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
            }

            #endif

            #ifdef FRAGMENT
 
            void main()
            {
                vec3 normalDirection = normalize(varyingNormalDirection);
 
                vec3 viewDirection = normalize(_WorldSpaceCameraPos - vec3(position));
                
                vec3 lightDirection;
                
                float attenuation;
 
                if (0.0 == WorldSpaceLightPos0.w)
                {
                    attenuation = 1.0;
                    
                    lightDirection = normalize(vec3(WorldSpaceLightPos0));
                }

                else
                {
                    vec3 vertexToLightSource = vec3(WorldSpaceLightPos0 - position);
                    
                    float distance = length(vertexToLightSource);
                    
                    attenuation = 1.0 / distance;
                    
                    lightDirection = normalize(vertexToLightSource);
                }

                vec3 fragmentColor = vec3(UnlitColor); 
            
                if (attenuation * max(0.0, dot(normalDirection, 
                lightDirection)) >= DiffuseThreshold)
                {
                    fragmentColor = vec3(LightColor0) * vec3(_Color); 
                }
            
                if (dot(viewDirection, normalDirection) < mix(UnlitOutlineThickness, LitOutlineThickness, 
                max(0.0, dot(normalDirection, lightDirection))))
                {
                    fragmentColor = vec3(LightColor0) * vec3(OutlineColor); 
                }
            
                if (dot(normalDirection, lightDirection) > 0.0 && attenuation 
                *  pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), Shininess) > 0.5)
                {
                    fragmentColor = SpecColor.a * vec3(LightColor0) 
                    * vec3(SpecColor) + (1.0 - SpecColor.a) * fragmentColor;
                }

                gl_FragColor = vec4(fragmentColor, 1.0);
            }

            #endif

            ENDGLSL
        }

        Pass
        {
            Tags
            {
                "LightMode" = "ForwardAdd"
            }

            Blend SrcAlpha OneMinusSrcAlpha

            GLSLPROGRAM

            uniform vec4 Colr; 
            
            uniform vec4 UnlitColor;
            
            uniform float DiffuseThreshold;
            
            uniform vec4 OutlineColor;
            
            uniform float LitOutlineThickness;
            
            uniform float UnlitOutlineThickness;
            
            uniform vec4 SpecColor; 
            
            uniform float Shininess;

            uniform vec3 WorldSpaceCameraPos; 

            uniform mat4 Object2World;

            uniform mat4 World2Object;
            
            uniform vec4 WorldSpaceLightPos0; 

            uniform vec4 LightColor0;

            varying vec4 position; 

            varying vec3 varyingNormalDirection;

            #ifdef VERTEX

            void main()
            {                                
                mat4 modelMatrix = Object2World;

                mat4 modelMatrixInverse = World2Object;

                position = modelMatrix * gl_Vertex;

                varyingNormalDirection = normalize(vec3(vec4(gl_Normal, 0.0) * modelMatrixInverse));

                gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
            }

            #endif

            #ifdef FRAGMENT

            void main()
            {
                vec3 normalDirection = normalize(varyingNormalDirection);
 
                vec3 viewDirection = normalize(WorldSpaceCameraPos - vec3(position));
                
                vec3 lightDirection;
                
                float attenuation;
 
                if (0.0 == WorldSpaceLightPos0.w)
                {
                    attenuation = 1.0;
                    
                    lightDirection = normalize(vec3(WorldSpaceLightPos0));
                }

                else
                {
                    vec3 vertexToLightSource = vec3(WorldSpaceLightPos0 - position);
                    
                    float distance = length(vertexToLightSource);
                    
                    attenuation = 1.0 / distance;
                    
                    lightDirection = normalize(vertexToLightSource);
                }
 
                vec4 fragmentColor = vec4(0.0, 0.0, 0.0, 0.0);

                if (dot(normalDirection, lightDirection) > 0.0 && attenuation 
                * pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess) > 0.5)
                {
                    fragmentColor = vec4(_LightColor0.rgb, 1.0) * _SpecColor;
                }
 
                gl_FragColor = fragmentColor;
            }

            #endif
 
            ENDGLSL
        }
    }
}