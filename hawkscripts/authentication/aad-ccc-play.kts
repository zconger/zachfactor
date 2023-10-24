import org.apache.commons.httpclient.URI
import org.apache.log4j.LogManager

import java.io.ByteArrayInputStream
import java.io.File
import java.security.MessageDigest
import java.security.cert.Certificate
import java.security.cert.CertificateFactory
import java.util.Locale
import javax.xml.bind.DatatypeConverter
import com.nimbusds.jwt.JWTClaimsSet
import java.util.Date
import com.nimbusds.jose.JWSHeader
import com.nimbusds.jose.JWSAlgorithm
import com.nimbusds.jose.JOSEObjectType
import com.nimbusds.jose.crypto.RSASSASigner
import com.nimbusds.jose.util.Base64URL
import com.nimbusds.jwt.SignedJWT
import java.net.URLEncoder
import com.nimbusds.jose.jwk.JWK
import java.security.cert.X509Certificate



val logger = LogManager.getLogger("AAD-CCC-PLAY")
LogManager.

println("Hello, AAD-CCC-PLAY.")

val appId = "d4b58aba-58c7-4e58-a604-b4d7c0b8f7f5"
val tenantId = "ca346305-52ed-45ea-8064-3c4e8196ea12"
val certFile = "/Users/zconger/git/github/zconger/zachfactor/keyster-zachlock-20231021.pfx"

logger.info("app ID: ${appId}")
logger.info("tenant ID: ${tenantId}")
logger.info("signing certificate: ${certFile}")

